-- Create TaskDB database
CREATE DATABASE TaskDB
GO
USE TaskDB
GO
-- Create Task Table
CREATE TABLE Task
(
    TaskID INT PRIMARY KEY IDENTITY(1,1),
    TaskRequester VARCHAR(100),
    TaskName VARCHAR(200),
    Deadline VARCHAR(100),
    Priority INT,
    TaskType VARCHAR(50)
)
-- Populate some test data into Task table
INSERT INTO Task VALUES
('Pranaya','Write Exam Notes','2025-05-10',1,'Exam'),
('Anurag','Do Biology Homework','2025-05-14',3,'Homework'),
('Priyanka','Go to movies','2025-07-01',10,'Entertainment')
GO