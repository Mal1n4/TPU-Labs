Отчет по лабораторной работе № 7

Рекурсивные запросы.

По дисциплине «Базы данных»

ЗАДАНИЕ 1

Получение списка всех родителей (непосредственных и вышестоящих) для заданного сотрудника (например, 112), но, чтобы “родителей” было не меньше 2 у выбранного сотрудника (для наглядности).

ЗАПРОС:

with recursive EmployeesHierarchy As (
 select e.employee_id as employee_id, e.manager_id as manager_id, 1 as level
 from hr.employees e
 where e.employee_id = 112
 UNION ALL
 select emp.employee_id, emp.manager_id, eh.level + 1
 from hr.employees emp  
 	inner join EmployeesHierarchy eh
  	on eh.manager_id=emp.employee_id
 )
 
 select employee_id, manager_id, level
 from EmployeesHierarchy order by level

РЕЗУЛЬТАТ ВЫПОЛЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/d6d0c5b6-6608-4fed-9cd0-11484b2648ae)

ЗАДАНИЕ 2

Подсчитайте количество подчиненных (всех уровней) для каждого сотрудника (для этого надо начинать с главного менеджера). При этом отсортировать по кол-ву подчиненных от большего к меньшему и вывести только первых 5 сотрудников, у кого кол-во подчинённых больше 0.

ЗАПРОС:

with recursive EmployeesHierarchy As (
select e.employee_id as employee_id, e.manager_id as manager_id, 1 as level
from hr.employees e
UNION ALL
select emp.employee_id, emp.manager_id, eh.level + 1
from hr.employees emp  
inner join EmployeesHierarchy eh
  	on eh.manager_id=emp.employee_id
)
 
select manager_id, count(employee_id) as employees_number
from EmployeesHierarchy
where manager_id is not null
group by manager_id
having count(employee_id)>0
order by employees_number DESC
limit 5

РЕЗУЛЬТАТ ВЫПОЛЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/69ec2fcc-293a-4d3e-8a70-ca2636d425e0)

ЗАДАНИЕ 3

Придумайте свой запрос с указанием пути иерархии.

ЗАПРОС:

 WITH RECURSIVE EmployeesHierarchy (employee_id, manager_id, full_name, path) AS (
SELECT e.employee_id, e.manager_id, concat(e.last_name, ' ', e.first_name), cast(concat(e.last_name, ' ', e.first_name) as varchar (50))
FROM hr.employees e
WHERE e.employee_id = 100
UNION ALL
SELECT emp.employee_id, emp.manager_id, concat(emp.last_name, ' ', emp.first_name), cast(eh.path || '->' || concat(emp.last_name, ' ', emp.first_name) as varchar(50))
FROM hr.employees emp INNER JOIN EmployeesHierarchy eh ON emp.manager_id = eh.employee_id
)
SELECT *
FROM EmployeesHierarchy
order by employee_id;

РЕЗУЛЬТАТ ВЫПОЛЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/a35bd0a0-f460-4781-872b-d5293b3f89b7)
