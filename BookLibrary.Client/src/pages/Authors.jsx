import { useEffect, useState } from "react";
import { authorsApi } from "../api";

export default function Authors() {
  const [authors, setAuthors] = useState([]);
  const [error, setError] = useState(null);
  const [form, setForm] = useState({ name: "", bio: "" });
  const [editId, setEditId] = useState(null);

  const loadAuthors = async () => {
    try {
      const data = await authorsApi.getAll();
      setAuthors(data);
      setError(null);
    } catch {
      setError("Kunde inte ansluta till API:et.");
    }
  };

  useEffect(() => { loadAuthors(); }, []);

  const handleSubmit = async () => {
    if (!form.name) return;
    try {
      if (editId) {
        await authorsApi.update(editId, { id: editId, ...form });
        setEditId(null);
      } else {
        await authorsApi.create(form);
      }
      setForm({ name: "", bio: "" });
      loadAuthors();
    } catch {
      setError("Något gick fel.");
    }
  };

  const handleEdit = (author) => {
    setEditId(author.id);
    setForm({ name: author.name, bio: author.bio });
  };

  const handleDelete = async (id) => {
    await authorsApi.delete(id);
    loadAuthors();
  };

  return (
    <div>
      <h2>Författare</h2>
      {error && <p style={{ color: "red" }}>{error}</p>}

      <div style={{ marginBottom: "1rem" }}>
        <input
          placeholder="Namn"
          value={form.name}
          onChange={e => setForm({ ...form, name: e.target.value })}
        />
        <input
          placeholder="Bio"
          value={form.bio}
          onChange={e => setForm({ ...form, bio: e.target.value })}
        />
        <button onClick={handleSubmit}>{editId ? "Uppdatera" : "Lägg till"}</button>
        {editId && <button onClick={() => { setEditId(null); setForm({ name: "", bio: "" }); }}>Avbryt</button>}
      </div>

      <table border="1" cellPadding="8">
        <thead>
          <tr><th>ID</th><th>Namn</th><th>Bio</th><th>Åtgärder</th></tr>
        </thead>
        <tbody>
          {authors.map(a => (
            <tr key={a.id}>
              <td>{a.id}</td>
              <td>{a.name}</td>
              <td>{a.bio}</td>
              <td>
                <button onClick={() => handleEdit(a)}>Redigera</button>
                <button onClick={() => handleDelete(a.id)}>Ta bort</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
