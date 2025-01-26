import React, { useEffect, useState } from "react";
import productService from "../../data/api/product.service";
import { Product } from "../../data/models/productmodels";
import { Box, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";

const ProductTable = ({products}:{products:Product[]}) => {

    return (
        <Box sx={{p:2}}>
            <Typography variant="h6">
                Products
            </Typography>
            <TableContainer>
                <Table aria-label="Products">
                    <TableHead>
                        <TableRow>
                        <TableCell>Name</TableCell>
                        <TableCell>Category</TableCell>
                        <TableCell>Product Code</TableCell>
                        <TableCell>Price</TableCell>
                        <TableCell>SKU</TableCell>
                        <TableCell>Stock Quantity</TableCell>
                        <TableCell>DateAdded</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                    {products.map((product: Product) => {
                        return (
                            <TableRow key={product.Id}>
                                <TableCell>{product.Name}</TableCell>
                                <TableCell>{product.Category}</TableCell>
                                <TableCell>{product.Code}</TableCell>
                                <TableCell>{product.Price}</TableCell>
                                <TableCell>{product.SKU}</TableCell>
                                <TableCell>{product.StockQuantity}</TableCell>
                                <TableCell>{new Date(product.DateAdded)?.toLocaleDateString()}</TableCell>
                            </TableRow>
                        )
                    })

                    }
                    </TableBody>
                </Table>
            </TableContainer>
        </Box>
    );
};

export default ProductTable;
