# Justus Grant: Smartwyre Developer Interview
😅 Thank you for considering me for this position. I hope my work here is satisfactory and look forward to having the pleasure of joining the SmartWyre Team. - Justus S Grant

---------------------------------------------------------------------------------------
1. I've introduced Dependency Injection and refactored this project to use DI.
   
3. I wrote unit tests for each of the 3 Incentive Types testing both success and failure cases
<img width="396" alt="Screenshot 2023-09-07 at 10 58 53 PM" src="https://github.com/JustusSGrant/Smartwyre_interview/assets/47908757/d23f4e4f-f661-45fb-bb82-d09027152e16">

3. I refactored the rebate service to use rebate & product to determine an initial success status. I've left the switch statement checking the rebate's IncentiveType so that the unique business logic associated with each incentive type can be preserved.

4. I renamed the "Types" namespace to "Models" to be more consistent with conventional naming conventions. 

5. I used Moq and NUnit to write the unit tests instead of using XUnit. 🙏🏿  Please don't take points away for this. It was intentional and a result of my own personal preference. I am still following the 3 A's of unit testing (Arrange, Act, Assert)

6. All services and data stores are referenced by their interfaces instead of being directly referenced.

7. No longer creating new instances of the data stores inappropriately.

