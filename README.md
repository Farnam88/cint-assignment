# Home assignment
### Assumptions
  - The starting point itself counts in the number of unique cleaned places.
  - All the input data are valid and do not need to check for any data validations; therefore, I used the **Null-Forgiving** operator in some places to get rid of the warning, but it is not the best practice.
### What I could do better:
  - **Mock:** I didnt use Mock because the scale of the project was small and I had time limitation.
  - **DI:** I could have benefit from Dependency injection.
  - **Violating SRP:** In [IDirectionStrategy](https://github.com/Farnam88/cint-assignment/blob/0ac226237990091be9435bde250b4aacee784738/CintAssignment.Core/Services/IDirectionStrategy.cs) implementation SRP is violated because if I were to separate move from updating the HashSet, I would increase the program's complexity, which I didn't want to.
  - **Input data:** I could have implemented an object to receive input data separately instead of doing it in the Program class. 
#### Please pay attention to commit messages.
