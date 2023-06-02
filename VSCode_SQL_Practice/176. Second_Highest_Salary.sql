/* Write your T-SQL query statement below */

--get the second max value

--1: order by, then use OFFSET FETCH , recommended
SELECT ISNULL(
       (
           SELECT DISTINCT salary AS Secondhighestsalary
           FROM employee
           ORDER BY salary DESC offset 1 rows FETCH next 1 rows only
       ),null) as Secondhighestsalary
GO;

--2: use MAX() and subquery, very slow
select MAX(salary) as SecondHighestSalary
from Employee
where salary <
(
    select MAX(salary) from Employee
)
GO;

--3 use rank() function, only works for unique columns 
select ISNULL(
       (
           select salary as SecondHighestSalary
           from
           (
               select salary,
                      rank() over (order by salary desc) as salaryRank
               from Employee
           ) t
           where t.settleRank = 2
       ),null) as Secondhighestsalary
GO;

--4 use row_number() function, works for no-unique columns 
select ISNULL(
       (
           select salary as SecondHighestSalary
           from
           (
               select salary,
                      row_number() over (order by salary desc) as salaryRank
               from Employee
           ) t
           where t.settleRank = 2
       ),null) as Secondhighestsalary
GO;