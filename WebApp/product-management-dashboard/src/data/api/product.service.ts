
class ProductService{

    getProducts(){
        if (process.env.REACT_APP_PRODUCTS_API) {
            return fetch(process.env.REACT_APP_PRODUCTS_API + 'products' ,
              {
                method: 'GET',
                headers: {
                  'Content-Type': 'application/json',
                }
              });
      
          }
    }
}

export default new ProductService();