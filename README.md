# DesignCrowdAssessment

## Approach

Task 1 and Task 2 are great base for TDD given that a class contract is mandated and test cases are offerred.
Using this approach, I could populate the common IBusinessDayCounter interface, lean test cases and then work on the implementation.

For Task 3, the idea is to provide a lean interface to allow various possible models/implementations to follow. Unit tests would cover the contracted behaviours.
Further extensions could be done via new implementations.

There is an assumption here that some public holidays that occur during the weekend can be deferred to the next Monday, Tuesday etc. We assume here that it's cumulative.

## Todo:
Task 1 = The algorithm used could be made much smarter by not iterating through all the days but rather than identifying the current day, find the offset till the weekend, and then extrapolating the total number of weekend days.
However the I would need to assess if the arithmetic complexity is warranted in favour of readability for the next developer. 
