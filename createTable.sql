-- Create DB
CREATE DATABASE TaskDB
GO
USE TaskDB
GO

-- Create Task Table
CREATE TABLE TodoTasks
(
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    TaskRequester VARCHAR(100),
    TaskName VARCHAR(200),
    Deadline VARCHAR(100),
    Priority INT,
    TaskType VARCHAR(50)
)