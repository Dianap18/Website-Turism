import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Header from "./Header";
import Banner from "./Banner";
import DestinationsGrid from "./DestinationsGrid";
import Footer from "./Footer";
import FiltersSection from "./FiltersSection";
import DestinationPage from "./DestinationPage";
import destinations from "./DestinationsData";

import './index.css';
import './principal.css';
import './DestinationPage.css'

export default function App() {
  return (
    <Router>
      <Header destinations={destinations} />
      <Routes>
        <Route path="/" element={
          <>
            <Banner />
            <FiltersSection />
            <DestinationsGrid destinations={destinations} />
          </>
        } />
        <Route path="/destinatie/:link" element={<DestinationPage destinations={destinations} />} />
      </Routes>
      <Footer />
    </Router>
  );
}
