import React, { useEffect, useState } from "react";
import { BarChart } from '@mui/x-charts/BarChart';
import { Product } from "../../data/models/productmodels";
const StockByCategoryChart = ({ products }: { products: Product[] }) => {
    const [chartData, setChartData] = useState<{ category: string; stockQuantity: number }[]>([]);

    useEffect(() => {

        const groupedData = products.reduce((acc: any, product: Product) => {
            const category = product.Category;
            if (!acc[category]) acc[category] = 0;
            acc[category] += product.StockQuantity;
            return acc;
        }, {});
        const chartFormattedData = Object.entries(groupedData).map(([category, stockQuantity]) => ({
            category,
            stockQuantity: stockQuantity as number,
        }));
        setChartData(chartFormattedData);


    }, [products]);


    return (
        <BarChart
            dataset={chartData}
            xAxis={[{ scaleType: 'band', dataKey: 'category' },]}
            yAxis={[{label:'Stock count'}]}
            series={[{ dataKey: 'stockQuantity', label: 'Stock count by category' }]}
            height={500}
        />
    );
};

export default StockByCategoryChart;
