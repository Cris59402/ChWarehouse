import { useNavigate } from "react-router-dom";
import "./HomePage.scss";
import { Button } from "@mui/material";
import warehouse from "../../assets/images/warehouse.jpg";

const HomePage = () => {
  const redirect = useNavigate();
  return (
    <div className="home">
      <h1>Welcome to our Warehouse</h1>
      <h3>Here you can storage your products</h3>
      <Button
        variant="outlined"
        color="primary"
        onClick={() => redirect("/products")}
      >
        Product list
      </Button>
      <img src={warehouse} alt="warehouse" />
    </div>
  );
};

export default HomePage;
