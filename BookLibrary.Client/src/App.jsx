import { useState } from "react";
import Authors from "./pages/Authors";
import Books from "./pages/Books";
import "./App.css";

export default function App() {
  const [page, setPage] = useState("authors");

  return (
    <div>
      <nav style={{ marginBottom: "1rem" }}>
        <button onClick={() => setPage("authors")}>Författare</button>
        <button onClick={() => setPage("books")}>Böcker</button>
      </nav>
      {page === "authors" ? <Authors /> : <Books />}
    </div>
  );
}
