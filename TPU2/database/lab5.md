Отчет по лабораторной работе № 5
По дисциплине «Базы данных»

ЗАДАНИЕ 1

Напишите запрос для отображения названия отдела и количества сотрудников в каждом из отделов и средней заработной платой в отделе, где средняя ЗП больше 10000 (можете подобрать другое число).

ЗАПРОС:

SELECT d.department_name, i.employees_number, i.average_dep_salary 
FROM hr.departments d, (SELECT COUNT(e.employee_id) AS employees_number, AVG(e.salary) AS average_dep_salary, e.department_id FROM hr.employees e GROUP BY e.department_id) i 
WHERE (d.department_id = i.department_id AND i.average_dep_salary>10000)

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/bc1243c7-7379-4a79-8248-356ceb2be620)

ЗАДАНИЕ 2

Напишите запрос для отображения полного имени (имени и фамилии), названия должности, даты начала для тех сотрудников, у которых не указан номер телефона.

ЗАПРОС:

SELECT concat(e.first_name, ' ', e.last_name) AS full_name, d.department_name, e.hire_date
FROM hr.employees e, hr.departments d
WHERE (e.department_id=d.department_id AND e.phone_number is NULL)

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/5f976920-816b-4c5b-98df-1c7b31acf5eb)

ЗАДАНИЕ 3

Напишите запрос для отображения идентификатора сотрудника, названия должности, в отделе с названием IT, у которых заработная плата более 5000.

ЗАПРОС:

SELECT e.employee_id, d.department_name FROM hr.employees e, hr.departments d WHERE e.department_id=d.department_id AND d.department_name='IT' AND e.salary>5000

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/88bf9975-eee0-4b0a-b0a1-784a94c4f2b1)

ЗАДАНИЕ 4

Напишите запрос для вывода всех отделов, в которых работают минимум 2 сотрудника, страну и город этих отделов, даже если они пустые.

ЗАПРОС:

SELECT d.department_name, cn.country_name, l.city   
FROM hr.departments d
	LEFT JOIN hr.locations l
	ON d.location_id=l.location_id
	left join hr.countries cn
	ON l.country_id=cn.country_id
WHERE (
	SELECT COUNT(e.employee_id)
	FROM hr.employees e
	WHERE (e.department_id=d.department_id)
	GROUP BY e.department_id)>=2
 
РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/ce7eec1e-92af-4be8-bab5-73c54d3164de)

ЗАДАНИЕ 5

Напишите запрос, чтобы отобразить название отдела и город, кол-во сотрудников этого отдела и кол-во детей всех сотрудников этого отдела. Внимательнее: у некоторых сотрудников нет детей.

ЗАПРОС:

SELECT d.department_name, l.city, emp_num.num As employees_number, kids_num.num AS kids_number
FROM hr.departments d
	LEFT JOIN hr.locations l
	ON d.location_id=l.location_id
	left join (SELECT COUNT(e.employee_id) AS num, e.department_id AS department_id FROM hr.employees e GROUP BY e.department_id) emp_num
	ON emp_num.department_id=d.department_id
	left join (
     	SELECT count(x.kid_id) As num, x.department_id As department_id
    	FROM (SELECT e.department_id AS department_id, e.employee_id AS e_id, dep.dependent_id AS kid_id
             	FROM hr.employees e
              	Left join hr.dependents dep
            	on dep.employee_id=e.employee_id) x
    	group by x.department_id
	) kids_num
 	on kids_num.department_id=d.department_id
  
РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/75783f9a-41d5-4fe5-b86a-ceafc94cfc8b)

ЗАДАНИЕ 6

Для каждого сотрудника укажите полное имя, название отдела, город и регион. Отсортируйте по Фамилии сотрудника в обратном порядке.

ЗАПРОС:

SELECT concat(e.last_name, ' ', e.first_name) as full_name, d.department_name, l.city, r.region_name   
FROM hr.employees e
	left join hr.departments d
	ON e.department_id=d.department_id
	LEFT JOIN hr.locations l
	ON d.location_id=l.location_id
	left join hr.countries cn
	ON l.country_id=cn.country_id
	LEft JOIN hr.regions r
	ON cn.region_id=r.region_id
ORDER BY e.last_name DESC

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/bf678862-5cb0-43c4-a456-5ba8c2a768fe)

ЗАДАНИЕ 7

Написать запрос для вывода полного имени (имени и фамилии) и зарплаты сотрудников и названия всех отделов, расположенных в штате Вашингтон.

ЗАПРОС:

SELECT concat(e.last_name, ' ', e.first_name) as full_name, e.salary, d.department_name   
FROM hr.employees e
	left join hr.departments d
	ON e.department_id=d.department_id
WHERE (SELECT l.state_province FROM hr.locations l WHERE l.location_id=d.location_id)='Washington'

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/4596e2d4-fa1c-4c50-a6f7-545b64ddfafb)

ЗАДАНИЕ 8

Выведите регионы, в которых нет ни одного отдела.

ЗАПРОС:

SELECT region
FROM (SELECT d.department_id AS department, r.region_name AS region
  FROM hr.departments d
  	LEFT join hr.locations l
  	ON d.location_id=l.location_id
  	LEFT join hr.countries cn
  	ON l.country_id=cn.country_id
  	RIGHT join hr.regions r
  	on cn.region_id=r.region_id)
WHERE department IS NULL

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/0b1d6920-da30-407c-a428-d4f04093d823)

ЗАДАНИЕ 9

Отобразите полное имя, название отдела, город и регион для всех сотрудников, фамилия которых содержит букву «o».

ЗАПРОС:

SELECT concat(e.last_name, ' ', e.first_name) as full_name, d.department_name, r.region_name   
FROM hr.employees e
	left join hr.departments d
	ON e.department_id=d.department_id
	left join hr.locations l
	ON d.location_id=l.location_id
	Left join hr.countries cn
	ON l.country_id=cn.country_id
	Left join hr.regions r
	on cn.region_id=r.region_id
WHERE e.last_name LIKE '%o%'

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/75ae952c-1a33-45b2-a051-51ed12bb5615)

ЗАДАНИЕ 10

Для каждого отдела отобразите номер отдела, название отдела, регион и максимальную ЗП в отделе и список сотрудников в виде "Фамилия И." разделенных через запятую.

ЗАПРОС:

SELECT d.department_id, d.department_name, r.region_name, (SELECT max(e.salary) FROM hr.employees e GROUP BY e.department_id HAVING e.department_id=d.department_id),
(SELECT string_agg(concat(e.last_name, ' ', left(e.first_name, 1), '.'), ', ') FROM hr.employees e GROUP BY e.department_id HAVING e.department_id=d.department_id)
FROM hr.departments d
	left join hr.locations l
	ON d.location_id=l.location_id
	Left join hr.countries cn
	ON l.country_id=cn.country_id
	Left join hr.regions r
	on cn.region_id=r.region_id
 
РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/2b631f13-05ab-4950-b757-de127b375d94)

ЗАДАНИЕ 11

Придумайте самостоятельно запрос, в двух вариантах с соединением в разделе WHERE и в разделе FROM (итого 2 запроса). Запросы должны быть основаны минимум на 3-х таблицах и включать различные условия.

ЗАПРОС:

1. 
select cn.country_name, count(e.employee_id) As employees_number
from hr.employees e
	left join hr.departments d
	on e.department_id=d.department_id
	left join hr.locations l
	on l.location_id=d.location_id
	left join hr.countries cn
	on l.country_id=cn.country_id
GROUP BY cn.country_id
order by cn.country_name
ИЛИ
select cn.country_name, count(e.employee_id) As employees_number
from hr.employees e
	NATURAL join hr.departments d
	NATURAL join hr.locations l
	NATURAL join hr.countries cn
GROUP BY cn.country_id
order by cn.country_name

2.  
select cn.country_name, count(e.employee_id) As employees_number
from hr.employees e, hr.departments d, hr.locations l, hr.countries cn
WHERE (e.department_id=d.department_id and l.location_id=d.location_id AND l.country_id=cn.country_id)
GROUP BY cn.country_name
order by cn.country_name

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

1.
![изображение](https://github.com/user-attachments/assets/3ab39f26-9269-412f-8e89-3711c3f86793)

2.

![изображение](https://github.com/user-attachments/assets/d226642e-ac45-4eff-a97b-739bbccec3fc)
