 curl.exe -v -X POST  http://localhost:5000/Admin/Register   -H 'cache-control: no-cache'  -H 'content-type: application/json'  `
 -d '{ \"Email\": \"test@test.com\", \"Password\": \"Test12345,\" }'

curl.exe -v -X POST  http://localhost:5000/admin/login   -H 'cache-control: no-cache'  -H 'content-type: application/json'  `
-d '{ \"Email\": \"test@test.com\", \"Password\": \"Test12345,\" }'

