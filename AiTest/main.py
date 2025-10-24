import ollama
import chromadb

documents = [
  "Llamas are members of the camelid family meaning they're pretty closely related to vicuñas and camels"
]

client = chromadb.Client()
collection = client.create_collection(name="docs")

# store each document in a vector embedding database
for i, d in enumerate(documents):
  response = ollama.embed(model="mxbai-embed-large", input=d)
  embeddings = response["embeddings"]
  collection.add(
    ids=[str(i)],
    embeddings=embeddings,
    documents=[d]
)
  
# an example input
prompt = "What animals are llamas related to?"

# generate an embedding for the input and retrieve the most relevant doc
response = ollama.embed(
  model="mxbai-embed-large",
  input=prompt
)
results = collection.query(
  query_embeddings=[response["embeddings"]],
  n_results=1
)
data = results['documents'][0][0]

# generate a response combining the prompt and data we retrieved in step 2
output = ollama.generate(
  model="deepseek-r1",
  prompt=f"Using this data: {data}. Respond to this prompt: {prompt}"
)

print(output['response'])