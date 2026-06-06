const API_URL = "http://localhost:5128/api";

export const authorsApi = {
  getAll: () => fetch(`${API_URL}/Authors`).then(r => r.json()),
  getById: (id) => fetch(`${API_URL}/Authors/${id}`).then(r => r.json()),
  create: (author) => fetch(`${API_URL}/Authors`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(author)
  }),
  update: (id, author) => fetch(`${API_URL}/Authors/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(author)
  }),
  delete: (id) => fetch(`${API_URL}/Authors/${id}`, { method: "DELETE" })
};

export const booksApi = {
  getAll: () => fetch(`${API_URL}/Books`).then(r => r.json()),
  getById: (id) => fetch(`${API_URL}/Books/${id}`).then(r => r.json()),
  create: (book) => fetch(`${API_URL}/Books`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(book)
  }),
  update: (id, book) => fetch(`${API_URL}/Books/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(book)
  }),
  delete: (id) => fetch(`${API_URL}/Books/${id}`, { method: "DELETE" })
};
