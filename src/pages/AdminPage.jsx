import { useState, useEffect } from "react";
import "./AdminPage.css";

export default function AdminPage() {
  const [bookings, setBookings] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5286/api/bookings")
      .then((res) => res.json())
      .then((data) => setBookings(data))
      .catch((err) => console.error(err));
  }, []);

  return (
    <div className="admin-container">
      <h1>Panou Administrare - Rezervări</h1>
      
      <div className="table-wrapper">
        <table className="bookings-table">
          <thead>
            <tr>
              <th>Data</th>
              <th>Client</th>
              <th>Email</th>
              <th>Destinație</th>
              <th>Perioada</th>
              <th>Total ($)</th>
            </tr>
          </thead>
          <tbody>
            {bookings.map((b) => (
              <tr key={b.id}>
                <td>{new Date(b.createdAt).toLocaleDateString("ro-RO")}</td>
                
                <td><strong>{b.name}</strong></td>
                
                <td>{b.email}</td>
                
                <td>{b.destination ? b.destination.title : "Destinație ștearsă"}</td>
                
                <td>{b.period}</td>
                <td className="price-cell">{b.totalPrice} USD</td>
              </tr>
            ))}
          </tbody>
        </table>
        {bookings.length === 0 && <p className="no-data">Nu există rezervări momentan.</p>}
      </div>
    </div>
  );
}