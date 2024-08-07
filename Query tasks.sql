CREATE DATABASE Task; #Creación de la db
USE Task; #Se selecciona la db
#Creación de la tabla
CREATE TABLE tasks (id int(10) primary key auto_increment, title varchar(50), description varchar(50), isComplete bool, createAt datetime);
SELECT * from tasks; #Select para comprobar los campos se hayan creado correctamente

