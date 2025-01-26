import React from "react";
import { render, screen } from "@testing-library/react";
import ProductTable from "../../components/products/producttable";
import { Product } from "../../data/models/productmodels";
import "@testing-library/jest-dom";

describe("ProductTable", () => {
  const mockHeaders = [
    "Name",
    "Category",
    "Product Code",
    "Price",
    "SKU",
    "Stock Quantity",
    "DateAdded",
  ];

  const mockProducts: Product[] = [
    {
      Id: 1, Name: "Product A",Category: "Category A",  Code: "PA123", Price: 100, SKU: "SKU123", StockQuantity: 50, DateAdded: new Date("2023-01-01").toISOString(),
    },
    {
      Id: 2, Name: "Product B", Category: "Category B", Code: "PB456", Price: 200, SKU: "SKU456", StockQuantity: 30, DateAdded: new Date("2023-02-01").toISOString(),
    },
  ];

  it("renders the product table with the correct headers", () => {
    render(<ProductTable products={[]} />);

    // Verify if all table headers are present
    mockHeaders.forEach((header) => {
      expect(screen.getByText(header)).toBeInTheDocument();
    });
  });

  it("renders the product table with data", () => {
    render(<ProductTable products={mockProducts} />);

    // Check if product data rows are displayed correctly
    mockProducts.forEach((product) => {
      expect(screen.getByText(product.Name)).toBeInTheDocument();
      expect(screen.getByText(product.Category)).toBeInTheDocument();
      expect(screen.getByText(product.Code)).toBeInTheDocument();
      expect(screen.getByText(product.Price.toString())).toBeInTheDocument();
      expect(screen.getByText(product.SKU)).toBeInTheDocument();
      expect(screen.getByText(product.StockQuantity.toString())).toBeInTheDocument();
      expect(
        screen.getByText(new Date(product.DateAdded).toLocaleDateString())
      ).toBeInTheDocument();
    });
  });

  it("renders no rows when products array is empty", () => {
    render(<ProductTable products={[]} />);

    // Cjeck no product rows are rendered
    expect(screen.queryByRole("row", { name: /Product A/i })).not.toBeInTheDocument();
  });
});
