--for at være sikker på jeg bruger bikestores som db
use BikeStores
go

--hent de første 3 fra stocks og products i schemaet production
select top 3* from production.stocks
select top 3* from production.products
go 

--indsæt data i product
insert into production.products(product_name, brand_id, category_id, model_year, list_price) values ('test product name', 9, 6, 2009, 99.95)
go

--check om det er indsat ved at vise det
select * from production.products where product_name = 'test product name' 
go

--fjern product efter det er vist
delete from production.products where product_name = 'test product name'
go 

--check om det er fjernet
select * from production.products where product_name = 'test product name'
go