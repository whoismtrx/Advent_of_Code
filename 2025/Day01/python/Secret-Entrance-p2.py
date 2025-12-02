#!/usr/bin/env python3
import sys
import re

def solve():
    p = 50
    t = 0
    
    content = sys.stdin.read()
    content = re.sub(r'([a-zA-Z])(\d)', r'\1 \2', content)
    tokens = content.replace(',', ' ').split()

    iterator = iter(tokens)
    
    try:
        while True:
            d = next(iterator)
            s = int(next(iterator))
            
            for _ in range(s):
                if d == 'R':
                    p += 1
                    if p == 100:
                        p = 0
                elif d == 'L':
                    p -= 1
                    if p == -1:
                        p = 99
                
                if p == 0:
                    t += 1
                    
    except StopIteration:
        pass

    print(t)

if __name__ == "__main__":
    solve()
