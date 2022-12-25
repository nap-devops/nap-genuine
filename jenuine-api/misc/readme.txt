curl -v -k https://localhost:5001/api/products/org/console-test/action/GetProducts
<<<<<<< HEAD

=======
curl -k https://localhost:5001/api/products/org/console-test/action/GetProducts
>>>>>>> 25fb1688ba5862acbdad6b7a13f5fc0abcf34060
curl -v -k https://localhost:5001/api/products/org/console-test/action/GetProductById/60fff72c6f026b194e8ba59b

curl -v -k -X DELETE https://localhost:5001/api/products/org/console-test/action/DeleteProductById/60fff72c6f026b194e8ba59b

curl -k -s -X PUT 'https://localhost:5001/api/products/org/console-test/action/UpdateProductById/60fff72c6f026b194e8ba59b' -d \
-H "Content-Type: application/json" -H "Accept: application/json" \
'{
  "ProductId": "19:08:12.3179287",
  "ProductName": "Aut Test product name",
  "Description": "TEST"
}'



curl -k -s -X POST \
'https://localhost:5001/api/products/org/console-test/action/AddProduct/' -H 'Content-Type: application/json' \
-d '{ "ProductId": "19:08:12.0002", "ProductName": "Aut Test product name sdfsdfsdf", "Description": "TEST"}'