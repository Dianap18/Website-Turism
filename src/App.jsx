import Header from "./Header";
import Banner from "./Banner";
import DestinationsGrid from "./DestinationsGrid";
import Footer from "./Footer";
import './index.css';
import './principal.css';


const destinations = [
  { title: "Route 66", imgSrc: "/ruta66.jpeg", link: "/route66" },
  { title: "Quebec City, Canada", imgSrc: "/quebec1.jpg", link: "/quebec" },
  { title: "Guanajuato, Mexic", imgSrc: "/guanajuato2.jpg", link: "/guanajuato" },
  { title: "Vientiane, Laos", imgSrc: "/laos2.jpg", link: "/laos" },
  { title: "Manama, Bahrain", imgSrc: "/bahrain2.jpg", link: "/bahrain" },
  { title: "Jaipur, India", imgSrc: "/jaipur2.jpg", link: "/jaipur" },
  { title: "Reykjavik, Iceland", imgSrc: "", link: "" },
  { title: "Santorini, Greece", imgSrc: "", link: "" },
  { title: "Kyoto, Japan", imgSrc: "", link: "" },
  { title: "Marrakech, Morocco", imgSrc: "", link: "" },
  { title: "Sydney, Australia", imgSrc: "", link: "" },
  { title: "Banff, Canada", imgSrc: "", link: "" },
];


export default function App() {
  return (
    <>
      <Header destinations={destinations} />
      <Banner />
      <DestinationsGrid destinations={destinations} />
      <Footer />
    </>
  );
}

