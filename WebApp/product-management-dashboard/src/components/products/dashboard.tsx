import { Card, Divider,Grid2 as Grid} from '@mui/material';

import React, { Suspense, useEffect, useState } from 'react';
import StockByCategoryChart from './stockbycategory';
import { Product } from '../../data/models/productmodels';
import productService from '../../data/api/product.service';

const ProductTable = React.lazy(() => import('./producttable'));
const ProductAddedTimeChart = React.lazy(() => import('./productaddedchart'));
const Dashboard = () => {
    const [products,setProducts]=useState<Product[]>([]);
     useEffect(() => {
            productService.getProducts()
                ?.then(response => response.json())
                .then(data => setProducts(data))
                .catch(error => console.error(error));
        }, []);
    return (
        <Suspense fallback={<div>Loading...</div>}>
            <Card sx={{m:2}} >
            <ProductTable products={products}/>
            </Card>
            <Grid  container spacing={2} sx={{m:2}}>
                <Grid size={6}>
                    <Card>
                    <ProductAddedTimeChart products={products}/>
                    </Card>
                </Grid>
                <Grid size={6}>
                <Card>
                    <StockByCategoryChart products={products}/>
                    </Card>
                </Grid>
            </Grid>
        </Suspense>

    )
}

export default Dashboard;