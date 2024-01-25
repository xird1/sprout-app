things to improve before moving to production:
1) front-end should be well layered, with validations and detach from endpoint project for better deployment management(like setting up CI-CD etc), setup minifiers, refactor
2) make separate login mechanism, asp identity is slow and so many overheads, so we will better control for authentication and authorization as well
3) prepare config files to be used in environment variables when deployed
4) prepare branches for different environments
