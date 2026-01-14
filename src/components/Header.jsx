import { useState } from "react"; 
import { Link } from "react-router-dom"; 
import './Header.css';

export default function Header({ destinations }) {
  const [open, setOpen] = useState(false);
  // in open pastram starea, daca e inchis sau deschis

  return (
    <nav className="navbar">
      <div className="nav-inner">

        <Link to="/" className="nav-logo">
          <h1><sup>Travel</sup>GUIDE</h1>
        </Link>

        <div className="nav-links">
          <Link to="/" className="nav-link">Acasă</Link>

          <div
            className="dropdown"
            onMouseEnter={() => setOpen(true)}
            onMouseLeave={() => setOpen(false)}
          >
            <span className="nav-link dropdown-btn">
              Destinații <i className="fa-solid fa-chevron-down"></i>
            </span>

            {/* Dacă variabila open este true atunci clasa CSS devine dropdown-menu open. 
            În CSS, clasa .open face meniul vizibil
            Dacă open este false, clasa rămâne doar dropdown-menu  */}
            <div className={`dropdown-menu ${open ? "open" : ""}`}>
              {/* destinations: lista cu toate orașele venită din baza de date 
                .map(...): ia fiecare element din listă și îl transformă într-un <Link> */}
              {destinations.map((d, i) => (
                <Link 
                    key={i} 
                    // Aici se construiește calea pe care o vede browserul.
                    to={`/destinatie/${d.slug}`} 
                    onClick={() => setOpen(false)} 
                >
                    {d.title}
                </Link>
              ))}
            </div>
          </div>
        </div>
      </div>
    </nav>
  );
}