## solution explanation ``triangle``

### part 1

#### approach
this solution simulates a circular dial with 100 positions, starting at position 50. for each line of input, it interprets the direction ("L" for left, "R" for right) and distance, then updates the position using modular arithmetic. 
every time the dial lands on 0, a counter is incremented. the code reads movement instructions one per line from standard input and outputs how many times the dial landed exactly at position 0.

#### Complexity
- **time complexity:** O(N), where N is the number of instructions.
- **space complexity:** O(1), not counting input size, as only a few integer variables are used.

---

### part 2

#### approach
this solution calculates how many pairs (i, j), with `1 ≤ i ≤ n` and `1 ≤ j ≤ m`, satisfy `(i + j) % 5 == 0`. 
instead of brute force, the program divides numbers into residue classes modulo 5 and counts how many ways residues from the two ranges can be combined to sum to a multiple of 5. it does so by first computing, for each residue, how many numbers in `1..n` and `1..m` fall into each class, then sums up the products of compatible pairs.

#### complexity
- **time complexity:** O(1), since all computations are done using simple arithmetic and array operations of fixed size.
- **space complexity:** O(1), only small arrays and integer variables are used.
