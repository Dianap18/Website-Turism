import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { useState, useEffect } from "react"; 

import Header from "./components/Header";
import Banner from "./components/Banner";
import DestinationsGrid from "./components/DestinationsGrid";
import Footer from "./components/Footer";
import FiltersSection from "./components/FiltersSection";
import TopDestinations from "./components/TopDestinations"; 
import DestinationPage from "./pages/DestinationPage";
import AdminPage from "./pages/AdminPage"; 

import './index.css';
import './principal.css'; 
import './pages/DestinationPage.css';

export default function App() {
  const [allDestinations, setAllDestinations] = useState([]);
  const [filteredDestinations, setFilteredDestinations] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5286/api/destinations")
      .then((res) => res.json())
      .then((data) => {
        setAllDestinations(data);
        setFilteredDestinations(data); 
      })
      .catch((err) => console.error("Eroare la conectare API:", err));
  }, []);

  const handleFilter = (filters) => {
    let results = allDestinations;

    if (filters.activity !== "Toate") {
       results = results.filter(d => 
          d.title.toLowerCase().includes(filters.activity.toLowerCase()) || 
          (d.description && d.description.toLowerCase().includes(filters.activity.toLowerCase()))
       );
    }

    if (filters.minPrice !== "") {
        results = results.filter(d => d.price >= parseInt(filters.minPrice));
    }

    if (filters.maxPrice !== "") {
        results = results.filter(d => d.price <= parseInt(filters.maxPrice));
    }

    if (filters.rating !== "Toate") {
      const minStars = parseInt(filters.rating);
      
      results = results.filter(d => {
        if (!d.reviews || d.reviews.length === 0) return false; 
        const total = d.reviews.reduce((acc, r) => acc + r.stars, 0);
        const avg = total / d.reviews.length;
        return avg >= minStars;
      });
    }

    setFilteredDestinations(results);
  };

  return (
    <Router>
      <Header destinations={allDestinations} />
      <Routes>
        <Route path="/" element={
          <>
            <Banner />
            <TopDestinations destinations={allDestinations} />
            <FiltersSection onFilterApply={handleFilter} />
            <DestinationsGrid destinations={filteredDestinations} />
          </>
        } />

        <Route path="/destinatie/:link" element={<DestinationPage />} />

        <Route path="/admin" element={<AdminPage />} />

      </Routes>
      <Footer />
    </Router>
  );
}