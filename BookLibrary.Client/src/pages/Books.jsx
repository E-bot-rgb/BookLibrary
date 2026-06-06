import { useEffect, useState } from "react";
import { booksApi, authorsApi } from "../api";

export default function Books() {
  const [books, setBooks] = useState([]);
  const [authors, setAuthors] = useState([]);
  const [error, setError] = useState(null);
  const [form, setForm] = useState({ title: "", year: "", authorId: "" });
  const [editId, setEditId] = useState(null);

  const loadData = async () => {
    try {
      const [booksData, authorsData] = await Promise.all([
        booksApi.getAll(),
        authorsApi.getAll()
      ]);
      setBooks(booksData);
      setAuthors(authorsData);
      setError(null);
    } catch {
      setError("Kunde inte ansluta till API:et.");
    }
  };

  useEffect(() => { loadData(); }, []);

  const handleSubmit = async () => {
    if (!form.title || !form.authorId) return;
    const book = { title: form.title, year: parseInt(form.year), authorId: parseInt(form.authorId) };
    try {
      if (editId) {
        await booksApi.update(editId, { id: editId, ...book });
        setEditId(null);
      } else {
        await booksApi.create(book);
      }
      setForm({ title: "", year: "", authorId: "" });
      loadData();
    } catch {
      setError("Något gick fel.");
    }
  };

  const handleEdit = (book) => {
    setEditId(book.id);
    setForm({ title: book.title, year: book.year, authorId: book.authorId });
  };

  const handleDelete = async (id) => {
    await booksApi.delete(id);
    loadData();
  };

  const getAuthorName = (id) => authors.find(a => a.id === id)?.name ?? "Okänd";

  return (
    <div>
      <h2>Böcker</h2>
      {error && <p style={{ color: "red" }}>{error}</p>}

      <div style={{ marginBottom: "1rem" }}>
        <input
          placeholder="Titel"
          value={form.title}
          onChange={e => setForm({ ...form, title: e.target.value })}
        />
        <input
          placeholder="År"
          type="number"
          value={form.year}
          onChange={e => setForm({ ...form, year: e.target.value })}
        />
        <select value={form.authorId} onChange={e => setForm({ ...form, authorId: e.target.value })}>
          <option value="">Välj författare</option>
          {authors.map(a => <option key={a.id} value={a.id}>{a.name}</option>)}
        </select>
        <button onClick={handleSubmit}>{editId ? "Uppdatera" : "Lägg till"}</button>
        {editId && <button onClick={() => { setEditId(null); setForm({ title: "", year: "", authorId: "" }); }}>Avbryt</button>}
      </div>

      <table border="1" cellPadding="8">
        <thead>
          <tr><th>ID</th><th>Titel</th><th>År</th><th>Författare</th><th>Åtgärder</th></tr>
        </thead>
        <tbody>
          {books.map(b => (
            <tr key={b.id}>
              <td>{b.id}</td>
              <td>{b.title}</td>
              <td>{b.year}</td>
              <td>{getAuthorName(b.authorId)}</td>
              <td>
                <button onClick={() => handleEdit(b)}>Redigera</button>
                <button onClick={() => handleDelete(b.id)}>Ta bort</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
