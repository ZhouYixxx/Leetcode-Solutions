/* Write your T-SQL query statement below */


--1: 使用 or，但是会使索引失效。数据量较大应该使用union代替
select name, population, area from World where area >= 3000000 or population >= 25000000

--2: 使用union
(select name, population, area from World where area >= 3000000) 
union 
(select name, population, area from World where population >= 25000000) 

--2: 使用not exists
select World.name,
       World.population,
       World.area
from World
where not exists
(
    select w.name
    from World w
    where World.area < 3000000
          and World.population < 25000000
          and w.name = World.name
)