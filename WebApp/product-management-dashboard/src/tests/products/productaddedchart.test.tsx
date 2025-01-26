import React from "react";
import { render, screen, waitFor } from "@testing-library/react";
import ProductsAddedChart from "../../components/products/productaddedchart";
import { Product } from "../../data/models/productmodels";
import "@testing-library/jest-dom";

describe("ProductsAddedChart", () => {
  const today = new Date();
  const oneWeekAgo = new Date(today);
  oneWeekAgo.setDate(today.getDate() - 7);
  const oneMonthAgo = new Date(today);
  oneMonthAgo.setMonth(today.getMonth() - 1);
  const lastYear = new Date(today);
  lastYear.setFullYear(today.getFullYear() - 1);

  const mockProducts: Product[] = [
    {
      Id: 1,
      Name: "Product A",
      Category: "Category A",
      Code: "PA123",
      Price: 100,
      SKU: "SKU123",
      StockQuantity: 50,
      DateAdded: today.toISOString(), 
    },
    {
      Id: 2,
      Name: "Product B",
      Category: "Category B",
      Code: "PB456",
      Price: 200,
      SKU: "SKU456",
      StockQuantity: 30,
      DateAdded: oneWeekAgo.toISOString(),
    },
    {
      Id: 3,
      Name: "Product C",
      Category: "Category C",
      Code: "PC789",
      Price: 150,
      SKU: "SKU789",
      StockQuantity: 20,
      DateAdded: oneMonthAgo.toISOString(), 
    },
    {
      Id: 4,
      Name: "Product D",
      Category: "Category D",
      Code: "PD101",
      Price: 120,
      SKU: "SKU101",
      StockQuantity: 40,
      DateAdded: lastYear.toISOString(), 
    },
  ];

  it("renders the bar chart with correct data", async () => {
    render(<ProductsAddedChart products={mockProducts} />);

    await waitFor(() => {
      expect(screen.getByText("This Week")).toBeInTheDocument();
      expect(screen.getByText("This Month")).toBeInTheDocument();
      expect(screen.getByText("This Year")).toBeInTheDocument();

      
    });

  });

  it("renders empty chart when no products are passed", async () => {
    render(<ProductsAddedChart products={[]} />);

    await waitFor(() => {
      expect(screen.getByText("This Week")).toBeInTheDocument();
      expect(screen.getByText("This Month")).toBeInTheDocument();
      expect(screen.getByText("This Year")).toBeInTheDocument();
    });

  });
});
