// MongoDB Local setup database commands
use BannersDB
db.createCollection('Banners')
db.Banners.insert({'BannerId': 1,'Html':'<html><head><meta charset='UTF-8'><title>Page Title</title></head><body><h1>BannerFlow</h1><p>BannerFlow Ad</p></body></html>','Created':new Date(),'Modified':new Date()})
db.Banners.find({})
db.Banners.update({ BannerId: 1 },
   {
     $set: { Html: '<html><body>Welcome</body></html>' },
     $set: { Created: new Date() }
   },
   { upsert: true }
)
-------------------------------------------------------------------------
Postman API Test are available on the following postman account.

postman: vieripk@hotmail.com 
user: bannerflowtest
pass: bannerflowtest

-------------------------------------------------------------------------
The API are as follow.

Get: http://localhost:53258/api/Banner/

GetById: http://localhost:53258/api/Banner/1

Post: http://localhost:53258/api/Banner/
{
    "BannerId": 4,
    "Html": "<html><head><meta charset='UTF-8'><title>Page Title</title></head><body><h1>BannerFlow</h1><p>BannerFlow Ad</p></body></html>",
    "Created": "2019-05-27T09:18:54.092Z"
}

Edit: http://localhost:53258/api/Banner/4
{
    "BannerId": 4,
    "Html": "<html><head><meta charset='UTF-8'><title>Page Title</title></head><body><h1>BannerFlow</h1><p>BannerFlow Modified Ad</p></body></html>",
    "Created": "2019-05-27T09:18:54.092Z",
    "Modified": "2019-05-27T09:20:20.092Z"
}

Delete
http://localhost:53258/api/Banner/3

Render
http://localhost:53258/api/Render/
