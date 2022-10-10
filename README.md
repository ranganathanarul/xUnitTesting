# xUnitTesting
.NET Core xUnit Testing

xUnit is a free, open source, community-focused unit testing tool for the .NET /.NET Core 
Frameworks. Written by the original inventor of NUnit v2, xUnit.Net is the latest technology for the unit 
testing C#, F#, VB.Net and Other .NET Languages

xUnit support 4 Types of Testing:

1. Facts – are tests which are always true. They test invariant conditions. (when we have some 
criteria that’s always must be met, regardless of data example when we test a controller’s
action to see if it’s returning the correct view)
2. Theory – are tests which are only true for a set of data (ex. Takes multiple different inputs 
and hold true for a set of a data, whereas a fact is always true, and tests invariant 
conditions)
    E.g.
    • [Fact (Skip=”this is broken”)]
    • [Theory(Skip=”we should skip this too”)]
3. InlineData - attributes that have sample argument values for each method parameter.
    E.g. 
    • [InlineData("RL1")]
4. Trait - attribute can be used to categorize related test methods by assigning an arbitrary 
name/value pair for each defined “Trait”
    E.g. [Trait("Learning Resource Tests", "Adding LR")]
    public void TestAdd() { ... 
    
 Package Reference:
    xUnit Package References use:
          1. Microsoft.NET.Test. Sdk , 
          2. Xunit , 
          3. xunit.runner.Visualstudio,
          4. coverlet.collector
          
 Links:
    a. https://xunit.net/
    b. https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
    c. Video Learning
        i. https://learn.microsoft.com/en-us/shows/visual-studio-toolbox/unit-testingxunit


![image](https://user-images.githubusercontent.com/85032095/194958220-8d906f80-6a84-43e7-ad67-bb146132ea61.png)
