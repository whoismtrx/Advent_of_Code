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
it starts at position 50 on a 0-99 track. input is read from stdin, tokenized to handle potential commas or whitespace, and parsed as pairs of direction and steps. 
for every step taken, the position `p` is updated: incrementing for 'R' (wrapping 99 to 0) and decrementing for 'L' (wrapping 0 to 99). if `p` hits 0 at any step, the total count `t` increases. finally, the total count is printed.

#### complexity
- **time complexity:** O(S), where S is the total number of individual steps taken across all instructions.
- **space complexity:** O(N), where N is the size of the input string stored in memory for tokenization.
