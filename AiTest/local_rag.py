import ollama
import chromadb
from chromadb.utils import embedding_functions
from pathlib import Path
import time

EMBEDDING_MODEL = "nomic-embed-text"
CHAT_MODEL = "gemma3"
#CHAT_MODEL = "deepseek-r1:1.5b"
PROMPT = "Du är en hjälpsam assistent som jobbar på storsjö (Storsjögymnasiet). Här är relevant information plockat från Storsjögymnasiet:"

# === 1. Initiera ChromaDB (lokal databas)
chroma_client = chromadb.Client()
collection = chroma_client.create_collection(name="docs")

def load_texts_from_folder(folder_path):
    texts = []
    folder = Path(folder_path)
    for file in folder.glob("*.txt"):
        with open(file, "r", encoding="utf-8") as f:
            clean_file = ""
            lines = f.readlines()
            for line in lines:
                if line == "":
                    continue
                else:
                    clean_file += line
            texts.append((file.name, clean_file))
    return texts
# === 3. Skapa embeddings och lägg in i databasen
def embed_and_store(texts):
    for name, text in texts:
        response = ollama.embeddings(model=EMBEDDING_MODEL, prompt=text)
        embedding = response["embedding"]
        collection.add(documents=[text], embeddings=[embedding], ids=[name])
    print(f"Lade till {len(texts)} dokument i databasen.")

# === 4. Sök liknande text
def search(query):
    q_embed = ollama.embeddings(model=EMBEDDING_MODEL, prompt=query)["embedding"]
    results = collection.query(query_embeddings=[q_embed], n_results=3)
    return results["documents"][0]

# === 5. Ställ en fråga till Llama3 baserat på träffarna
def ask(question):
    start_time = time.time()
    relevant_docs = search(question)
    context_time = time.time() - start_time
    context = "\n\n".join(relevant_docs)
    prompt = f"{PROMPT}\n{context}\n\nFråga: {question}"
    answer = ollama.chat(model=CHAT_MODEL, messages=[{"role": "user", "content": prompt}])
    answer_time = time.time() - start_time
    print("\n=== SVAR ===")
    print(f"Tid att söka efter svar: {context_time:.2f}s")
    print(f"Tid att generera ett svar: {answer_time:.1f}s")
    print(answer["message"]["content"])

# === Körflöde ===
if __name__ == "__main__":
    texts = load_texts_from_folder("data")
    embed_and_store(texts) 
    while True:
        q = input("\nStäll en fråga (eller 'q' för att avsluta): ")
        if q.lower() == "q":
            break
        ask(q)