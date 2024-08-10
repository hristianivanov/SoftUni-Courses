import About from "./components/About"
import Footer from "./components/Footer"
import Header from "./components/Header"
import Loader from "./components/Loader"
import Navigation from "./components/Navigation"
import Protein from "./components/Protein"
import Testimonial from "./components/Testimonial"
import Growyhing from "./components/Growyhing"

export default function App() {
  return (
    <>
      <Loader />
      <Navigation />
      <Header />
      <Protein />
      <Growyhing />
      <Testimonial/>
      <About />
      <Footer />
    </>
  )
}
