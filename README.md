# Flexera coding test
This test is to assess one's ability to write world class production code that would be included in our Flexera products 

## Problem

Some applications from vendors are allowed to be installed on multiple computers per user with specific restrictions. In our scenario, each copy of the application (ID 374) allows the user to install the application on to two computers if at least one of them is a laptop. Given the provided data, create a utility that would calculate the minimum number of copies of the application the company must purchase. 

### Example 1:

Given the following scenario,  only one copy of the application is required as the user has installed it on two computers, with one of them being a laptop. 
  
ComputerID  |   UserID  |    ApplicationID  |   ComputerType    |   Comment 
------------|-----------|-------------------|-------------------|----------
1           |   1       |   374             |   LAPTOP          |   Exported from System A 
2           |   1       |   374             |   DESKTOP         |   Exported from System A 


### Example 2:

In the following scenario, three copies of the application are required as UserID 2 has installed the application on two computers, but neither of them is a laptop and thus both computers require a purchase of the application. 

ComputerID  |   UserID  |    ApplicationID  |   ComputerType    |   Comment 
------------|-----------|-------------------|-------------------|----------
1           |   1       |   374             |   LAPTOP          |   Exported from System A 
2           |   1       |   374             |   DESKTOP         |   Exported from System A 
3           |   2       |   374             |   DESKTOP         |   Exported from System A 
4           |   2       |   374             |   DESKTOP         |   Exported from System A 

### Example 3:

Occasionally the data may contain duplicate records as in the following scenario where only two copies of the application are required as the data from the second and third rows are effectively duplicates even though the ComputerType is lower case and the comment is different.    

ComputerID  |   UserID  |    ApplicationID  |   ComputerType    |   Comment 
------------|-----------|-------------------|-------------------|----------
1           |   1       |   374             |   LAPTOP          |   Exported from System A 
2           |   2       |   374             |   DESKTOP         |   Exported from System A 
2           |   2       |   374             |   desktop         |   Exported from System B

## Expectations
Please provide a solution that calculates the minimum of copies of the application with ID 374 a company must purchase and include some unit tests to show that your code has basic test coverage. 

- Please design and write this code to cover the full set of non-functional concerns you would expect from a software product with high quality 
- Please create a branch in this format candidate_<your_initials>, e.g. candidate_r_d, and use it for your submission 
- We're looking for extensibility, readability and clean, non-repeated code
- Make assumptions where you need to - it will be hard to showcase everything but add a few comments in your README to let us know
- Please provide instructions on how to build and run in the top level README

### Safe assumptions to make
You will not have to consider unexpected situations such as empty values, computers with multiple users or computers that are both desktops and laptops.

Rusten Line's comments:
- I used Visual Studio 2022 (free version). I recommend you use it as well.
- ApplicationID and "only two copies of the application are required" per user are hard coded. Obviously, they should be configurable in reality.
- 3 Unit tests are included in the Development version (change Solution Configuration to Debug in Visual Studio) and another test covering sample-small.csv as well.
- The app does not check all the possible situations that may go wrong.
- To test the production version, change the Solution Configuration to Release. I test it quickly without having to deploy it by going to \FlexeraCodingTest\FlexeraCodingTest\bin\Release\net6.0
folder and launching FlexeraCodingTest.exe. To have a proper test, one should build an installation package and test on a clean PC.
- Deployment instructions are out of scope but could be provided upon request.
