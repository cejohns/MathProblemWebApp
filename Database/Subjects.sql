CREATE DATABASE MathDatabase;
GO

USE MathDatabase;
GO

-- Subjects Table
CREATE TABLE Subjects (
    SubjectID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX)
);

-- Topics Table
CREATE TABLE Topics (
    TopicID INT IDENTITY(1,1) PRIMARY KEY,
    SubjectID INT NOT NULL,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);

-- Problems Table
CREATE TABLE Problems (
    ProblemID INT IDENTITY(1,1) PRIMARY KEY,
    TopicID INT NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Solution NVARCHAR(MAX) NOT NULL,
    Hint NVARCHAR(MAX),
    Difficulty NVARCHAR(50) CHECK (Difficulty IN ('Easy', 'Medium', 'Hard')),
    Complexity NVARCHAR(50) CHECK (Complexity IN ('Simple', 'Intermediate', 'Advanced')),
    FOREIGN KEY (TopicID) REFERENCES Topics(TopicID)
);

-- Proofs Table
CREATE TABLE Proofs (
    ProofID INT IDENTITY(1,1) PRIMARY KEY,
    TopicID INT NOT NULL,
    Statement NVARCHAR(MAX) NOT NULL,
    Proof NVARCHAR(MAX),
    DiagramURL NVARCHAR(255),
    FOREIGN KEY (TopicID) REFERENCES Topics(TopicID)
);

-- Definitions Table
CREATE TABLE Definitions (
    DefinitionID INT IDENTITY(1,1) PRIMARY KEY,
    TopicID INT NOT NULL,
    Term NVARCHAR(255) NOT NULL,
    Definition NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (TopicID) REFERENCES Topics(TopicID)
);
GO
