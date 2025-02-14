Отчет по лабораторной работе № 6
По дисциплине «Базы данных»

ЗАДАНИЕ 1

Возвратите отделы и среднюю зарплату для каждого отдела, где средняя зарплата для отдела меньше, чем средняя зарплата для всех сотрудников.

ЗАПРОС:

SELECT department_id, round(AVG(salary)) AS department_avg_salary FROM employees GROUP BY department_id HAVING AVG(salary) < (SELECT AVG(salary) FROM employees)

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/a93f03d1-244a-4bae-a139-ec8106a3c7b8)

ЗАДАНИЕ 2

Вернуть имена, наименование отдела для сотрудников, получающих ту же зарплату, что и «Alexander»

ЗАПРОС:

SELECT first_name, department_id, salary FROM employees WHERE salary IN (SELECT salary FROM employees WHERE first_name = 'Alexander')

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/80debd47-7dfb-4636-9b61-661139e36389)

ЗАДАНИЕ 3

Вывести id сотрудника, его имя, фамилию, должность, зарплата, максимальная зарплата по его должности, а также разница между максимальной зарплатой по его должности и зарплатой этого сотрудника, при условии, что эта разница не равна нулю.

ЗАПРОС:

SELECT a.employee_id, a.first_name, a.last_name, a.job_id, a.salary, b.max_salary, (b.max_salary - a.salary) AS dif FROM employees a, (SELECT job_id, MAX(salary) AS max_salary FROM employees GROUP BY job_id) b WHERE a.job_id = b.job_id AND (b.max_salary - a.salary)>0

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/2fbe9efc-d1d1-40da-bff0-6aa5074fed9a)

ЗАДАНИЕ 4

Вывести сотрудников, у которых стаж работы больше среднего стажа в их отделе.

ЗАПРОС:

SELECT a.employee_id, concat(a.last_name, ' ', a.first_name) AS name FROM employees a, (SELECT department_id, AVG(date_part('year', hire_date)) AS avg_exp FROM employees GROUP BY department_id) b WHERE a.department_id = b.department_id AND date_part('year', a.hire_date) < b.avg_exp

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/9ead4504-14d4-4c0e-b61f-c3465afdb480)

ЗАДАНИЕ 5

Все имя и фамилию менеджера в одном столбце, суммарную плату его подчиненных. Отсортировать по убыванию средней заработной платы. Реализовать 2 способами, один из которых с помощью коррелированного подзапроса, второй нет.

ЗАПРОС:

1.

SELECT (SELECT concat(first_name, ' ', last_name) AS manager_full_name FROM employees WHERE employee_id = a.manager_id), SUM(salary) AS sum_salary FROM employees a GROUP BY manager_id ORDER BY AVG(salary) DESC

2.

SELECT concat(a.first_name, ' ', a.last_name) AS manager_full_name, b.sum_salary AS sum_salary FROM employees a, (SELECT COUNT(employee_id) AS employees_number, SUM(salary) AS sum_salary, manager_id FROM employees GROUP BY manager_id) b WHERE employee_id=b.manager_id ORDER BY b.sum_salary/b.employees_number DESC

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

1.

![изображение](https://github.com/user-attachments/assets/80e64c43-170f-4769-b49a-49e51548348c)

2.

![изображение](https://github.com/user-attachments/assets/27bfacc4-a04e-49ff-a6c7-9e69fb6e0e63)

ЗАДАНИЕ 6

Придумать запрос с многостолбцовым подзапросом.

ЗАПРОС:

1.  Менеджеры, у подчиненных которых средняя зарплата больше 5000.

SELECT concat(a.last_name, ' ', a.first_name) AS manager_full_name, a.salary FROM employees a, (SELECT manager_id, AVG(salary) AS avg_salary FROM employees GROUP BY manager_id) b WHERE b.manager_id=a.employee_id AND b.avg_salary>5000

3. Сотрудники, у которых зарплата выше средней по их специальности в компании. 

SELECT concat(last_name, ' ', first_name) AS full_name FROM employees a, (SELECT AVG(salary) AS job_avg_salary, job_id FROM employees GROUP BY job_id) b WHERE (b.job_id=a.job_id AND a.salary > b.job_avg_salary)

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

1.
![изображение](https://github.com/user-attachments/assets/36ead508-6b49-4a79-b172-33129f67a5a0)

2.
![изображение](https://github.com/user-attachments/assets/ef1501f5-aa45-446a-a19c-0ad0d7105203)

ЗАЩИТА

Вывести имена, зарплату сотрудников и среднюю зарплату, зарплата которых больше средней минимум в два раза.

ЗАПРОС:

SELECT concat(a.last_name, ' ', a.first_name) AS name, a.salary, b.avg_salary FROM employees a, (SELECT AVG(salary) AS avg_salary FROM employees) b WHERE a.salary >= 2*b.avg_salary 

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/aac9f6c5-cc52-46cd-b099-1b557041d364)
