 /*--Create the Subjects table
CREATE TABLE Subjects (
   SubjectID INTEGER PRIMARY KEY, -- Automatically increments
 Name TEXT NOT NULL,
 Description TEXT
)*/

/*-- Insert data into Subjects table
INSERT INTO Subjects (SubjectID, Name, Description)
VALUES 
(1, 'Basic Math', 'Addition, subtraction, multiplication, and division.'),
(2, 'Logic', 'Truth tables, logical connectives, and quantifiers.'),
(3, 'Sets and Relations', 'Operations on sets, Cartesian products, and equivalence relations.'),
(4, 'Simple Interest', 'Calculating interest using basic formulas.'),
(5, 'Compound Interest', 'Applying compound interest formulas.'),
(6, 'Unit Circle', 'Understanding trigonometric values on the unit circle.'),
(7, 'Linear Equations', 'Solving equations with one variable.'),
(8, 'Quadratic Equations', 'Methods to solve quadratic equations.'),
(9, 'Probability', 'Basic probability rules and applications.'),
(10, 'Sequences', 'Properties and behavior of numerical sequences.'),
(11, 'Quantum Mechanics', 'Mathematical foundations of quantum theory.'),
(12, 'PDEs', 'Partial differential equations and their applications.'),
(13, 'Open and Closed Sets', 'Basics of topology and continuity.'),
(14, 'Groups', 'Introduction to group theory in abstract algebra.'),
(15, 'Complex Functions', 'Analysis of complex numbers and mappings.');
*/

SELECT * FROM Subjects;

/*CREATE TABLE Problems (
    ProblemID INTEGER PRIMARY KEY, -- Automatically increments
    SubjectID INTEGER NOT NULL,
    Problem TEXT NOT NULL,
    Solution TEXT NOT NULL,
    Hint TEXT,
    Difficulty TEXT CHECK (Difficulty IN ('Easy', 'Medium', 'Hard')) DEFAULT 'Medium',
    Complexity TEXT CHECK (Complexity IN ('Simple', 'Intermediate', 'Advanced')) DEFAULT 'Intermediate',
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);*/

-- Insert data into Problems table
/*INSERT INTO Problems (SubjectID, Problem, Solution, Hint, Difficulty, Complexity)
VALUES
(1, 'What is 5 + 3?', '8', 'Add the two numbers.', 'Easy', 'Simple'),
(1, 'What is 12 ÷ 4?', '3', 'Divide the numerator by the denominator.', 'Easy', 'Simple'),
(2, 'Solve for x: 2x + 5 = 11.', 'x = 3', 'Isolate x by subtracting 5 and dividing by 2.', 'Medium', 'Intermediate'),
(3, 'What is the simple interest for P=2000, r=10%, t=3 years?', '600', 'Use the formula I = P * r * t.', 'Medium', 'Intermediate'),
(4, 'Find the sine of 90°.', '1', 'Think of the trigonometric unit circle.', 'Easy', 'Simple'),
(5, 'Solve the quadratic equation x^2 - 7x + 10 = 0.', 'x = 2, x = 5', 'Factorize the quadratic expression.', 'Hard', 'Intermediate'),
(6, 'What is the probability of rolling a sum of 7 with two dice?', '1/6', 'List all possible outcomes for a sum of 7.', 'Medium', 'Intermediate'),
(7, 'Determine the limit of 1/x as x approaches infinity.', '0', 'As x increases, 1/x approaches zero.', 'Hard', 'Intermediate'),
(8, 'Calculate the eigenvalues of the matrix [[2, 1], [1, 2]].', '3, 1', 'Find the roots of the characteristic polynomial.', 'Hard', 'Advanced'),
(9, 'Solve the ODE: dy/dx = 3x^2.', 'y = x^3 + C', 'Integrate both sides with respect to x.', 'Medium', 'Intermediate');
*/

--SELECT * FROM Problems;
