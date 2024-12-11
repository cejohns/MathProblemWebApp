 /*--Create the Subjects table
CREATE TABLE Subjects (
   SubjectID INTEGER PRIMARY KEY, -- Automatically increments
 Name TEXT NOT NULL,
 Description TEXT
)*/

 --Insert data into Subjects table
/**INSERT INTO Subjects (SubjectID, Name, Description)
VALUES 

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
**/



--SELECT * FROM Subjects;

/**CREATE TABLE Problems (
    ProblemID INTEGER PRIMARY KEY, -- Automatically increments
    SubjectID INTEGER NOT NULL,
    Problem TEXT NOT NULL,
    Solution TEXT NOT NULL,
    Hint TEXT,
    Difficulty TEXT CHECK (Difficulty IN ('Easy', 'Medium', 'Hard')) DEFAULT 'Medium',
    Complexity TEXT CHECK (Complexity IN ('Simple', 'Intermediate', 'Advanced')) DEFAULT 'Intermediate',
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);**/

-- Insert data into Problems table
/**INSERT INTO Problems (SubjectID, Problem, Solution, Hint, Difficulty, Complexity)
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
**/

--SELECT * FROM Problems;

/**CREATE TABLE Proofs (
    ProofID INTEGER PRIMARY KEY,
    SubjectID INTEGER NOT NULL,
    Statement TEXT NOT NULL,
    Proof TEXT,
    DiagramURL TEXT,
    FOREIGN KEY (SubjectID) REFERENCES Subject(SubjectID) 
);**/

/**INSERT INTO Proofs (SubjectID, Statement, Proof, DiagramURL)
VALUES
(1, 'Sum of angles in a triangle', 'The sum of angles in a triangle is 180°.', 'https://example.com/triangle-proof.png'),
(2, 'Logical Equivalence', 'De Morgan’s Laws: NOT(A AND B) is equivalent to (NOT A) OR (NOT B).', NULL),
(3, 'Pythagorean Theorem', 'In a right triangle, a² + b² = c², where c is the hypotenuse.', 'https://example.com/pythagorean-proof.png');
**/

--SELECT * FROM Proofs;

/**INSERT INTO Proofs (SubjectID, Statement, Proof, DiagramURL)
VALUES
(1, 'The product of two negative numbers is positive.', 
    'Let a = -x and b = -y, where x, y > 0. Then ab = (-x)(-y) = xy, which is positive because x, y > 0.', 
    NULL),

(1, 'The sum of two even numbers is even.', 
    'Let a = 2m and b = 2n, where m, n are integers. Then a + b = 2m + 2n = 2(m + n), which is divisible by 2, proving it is even.', 
    NULL),

(1, 'The slope of a line is constant.', 
    'The slope between two points (x1, y1) and (x2, y2) is m = (y2 - y1) / (x2 - x1). For any other points on the line, the slope remains constant due to the equation y = mx + b.', 
    NULL),

(4, 'Sum of angles in a triangle', 'Draw a line parallel to one side of the triangle and use alternate interior angles. The three angles form a straight line, summing to 180°.', 
    'https://example.com/triangle-proof.png'),

(5, 'A quadratic equation has at most two roots.', 
    'The quadratic equation ax^2 + bx + c = 0 can be solved using the quadratic formula x = (-b ± √(b^2 - 4ac)) / (2a). The discriminant b^2 - 4ac determines the number of roots: zero, one, or two.', 
    NULL),

(6, 'sin^2(x) + cos^2(x) = 1.', 
    'From the unit circle, any point (x, y) satisfies x^2 + y^2 = 1. Substituting x = cos(x) and y = sin(x) gives cos^2(x) + sin^2(x) = 1.', 
    NULL),

(7, 'The limit of the sum is the sum of the limits.', 
    'By the definition of limits, the function values approach their respective limits as x approaches c. Adding these limits gives the result.', 
    NULL),

(8, 'The determinant of a triangular matrix is the product of its diagonal elements.', 
    'In a triangular matrix, elements below or above the diagonal are zero. Expanding along any row or column involves only the diagonal elements.', 
    NULL),

(9, 'The solution of dy/dx = ky is y = Ce^(kx).', 
    'Separating variables gives (1/y) dy = k dx. Integrating both sides results in ln(y) = kx + C, which leads to y = Ce^(kx).', 
    NULL),

(10, 'The sum of the first n integers is n(n+1)/2.', 
    'Pair the numbers (1, n), (2, n-1), ... Each pair sums to (n+1), and there are n/2 pairs. The total sum is n(n+1)/2.', 
    NULL),

(11, 'The set of integers under addition is a group.', 
    'The integers satisfy closure, associativity, identity (0), and inverses (-a) under addition.', 
    NULL),

(12, 'A continuous function on a closed interval is bounded.', 
    'By the Extreme Value Theorem, a continuous function on [a, b] attains a maximum and minimum, proving boundedness.', 
    NULL),

(13, 'e^(iπ) + 1 = 0.', 
    'By Euler''s formula e^(ix) = cos(x) + i*sin(x), substituting x = π gives e^(iπ) = -1. Adding 1 gives 0.', 
    NULL),

(14, 'The expected value of a constant is the constant itself.', 
    'E(c) = Σ cP(x) = cΣ P(x) = c because Σ P(x) = 1.', 
    NULL),

(15, 'A closed subset of a compact space is compact.', 
    'Any open cover of the closed subset can be extended to an open cover of the compact space, which has a finite subcover. Restricting this subcover gives compactness.', 
    NULL),

(16, 'There are infinitely many primes.', 
    'Assume finitely many primes p1, p2, ..., pn. Consider N = p1p2...pn + 1. N is not divisible by any pi, contradicting finiteness.', 
    NULL),

(17, 'The power set of a set S has 2^n elements.', 
    'Each element in S can either be included or excluded from a subset, resulting in 2^n subsets.', 
    NULL),

(18, 'The Schrödinger equation is linear.', 
    'For any ψ1 and ψ2, and constants a, b, H(aψ1 + bψ2) = aHψ1 + bHψ2, satisfying linearity.', 
    NULL);**/

--SELECT * FROM Proofs;

-- Definitions Table
/**CREATE TABLE Definitions (
    DefinitionID INTEGER PRIMARY KEY,
    SubjectID INTEGER NOT NULL,
    Term TEXT NOT NULL,
    Definition TEXT NOT NULL,
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);**/

/**INSERT INTO Definitions (SubjectID, Term, Definition)
VALUES 
(1, 'Addition', 'The process of finding the total or sum by combining two or more numbers.'),
(1, 'Subtraction', 'The process of taking one number away from another.'),
(2, 'Logic', 'The study of reasoning, including the principles of valid inference and demonstration.'),
(2, 'Set', 'A collection of distinct objects, considered as an object in its own right.'),
(3, 'Linear Equation', 'An equation that makes a straight line when graphed.'),
(4, 'Angle', 'A figure formed by two rays sharing a common endpoint.'),
(5, 'Quadratic Equation', 'A second-degree polynomial equation of the form ax^2 + bx + c = 0.');
**/

SELECT * FROM Definitions;


