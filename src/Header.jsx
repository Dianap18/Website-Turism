import { useState } from "react";

export default function Header({ destinations }) {
  const [open, setOpen] = useState(false);

  return (
    <nav className="navbar">
      <div className="nav-inner">

        <a href="/" className="nav-logo">
          <h1><sup>Travel</sup>GUIDE</h1>
        </a>

        <div className="nav-links">
          <a href="/" className="nav-link">Acasă</a>

          <div
            className="dropdown"
            onMouseEnter={() => setOpen(true)}
            onMouseLeave={() => setOpen(false)}
          >
            <span className="nav-link dropdown-btn">
              Destinații <i className="fa-solid fa-chevron-down"></i>
            </span>

            <div className={`dropdown-menu ${open ? "open" : ""}`}>
              {destinations.map((d, i) => (
                <a key={i} href={d.link}>{d.title}</a>
              ))}
            </div>
          </div>
          <a href="/" className="nav-link">Contact</a>
        </div>

      </div>
    </nav>
  );
}
