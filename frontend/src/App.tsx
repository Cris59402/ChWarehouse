import React from "react";
import Navbar from "./component/Navbar/Navbar";
import { Route, Routes } from "react-router-dom";
import HomePage from "./pages/Home/HomePage";
import ProductsPage from "./pages/Products/ProductsPage";
import Add from "./pages/Add/Add";
import Delete from "./pages/Delete/Delete";
import Edit from "./pages/Edit/Edit";

const App = () => {
  return (
    <div>
      <Navbar />

      <div className="wrapper">
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/products">
            <Route index element={<ProductsPage />} />
            <Route path="add" element={<Add />} />
            <Route path="edit/:id" element={<Edit />} />
            <Route path="delete/:id" element={<Delete />} />
          </Route>
        </Routes>
      </div>
    </div>
  );
};

export default App;
