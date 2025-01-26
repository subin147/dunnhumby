import React, { useEffect, useState } from "react";
import { BarChart } from '@mui/x-charts/BarChart';
import { Product } from "../../data/models/productmodels";
const ProductsAddedChart = ({ products }: { products: Product[] }) => {
    const [chartData, setChartData] = useState<{ period: string; count: number }[]>([]);

    useEffect(() => {
        debugger;
        const periods = {
            week: products.filter((product: Product) => getWeekNumber(new Date(product.DateAdded)) == getWeekNumber(new Date)).length,
            month: products.filter((product: Product) => new Date(product.DateAdded).getMonth() == new Date().getMonth()).length,
            year: products.filter((product: Product) => new Date(product.DateAdded).getFullYear() == new Date().getFullYear()).length,
        };
        const chartFormattedData = [
            { period: "This Week", count: periods.week },
            { period: "This Month", count: periods.month },
            { period: "This Year", count: periods.year },
        ];
        setChartData(chartFormattedData);

    }, [products]);

    function getWeekNumber(date: Date) {
        const startDate = new Date(date.getFullYear(), 0, 1);
        const days = Math.floor((date.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24));
        const weekNumber = Math.ceil((days + 1) / 7);

        return weekNumber;
    }


    return (
        <BarChart
            dataset={chartData}
            xAxis={[{ scaleType: 'band', dataKey: 'period' },]}
            yAxis={[{label:'Stock added per period'}]}
            series={[{ dataKey: 'count', label: 'Stock added per period' }]}
            
            height={500}
        />
    );
};

export default ProductsAddedChart;
