// See https://aka.ms/new-console-template for more information
using System;


Random random = new();


var currentNumber = 1001;
var stopNumber = 0;

// Continue executing the loop until 'currentNumber' equals to 'stopNumber'
while (currentNumber != stopNumber)
{
    // Generates a random number between 'stopNumber' and 'currentNumber' and assigns it to 'currentNumber'
    currentNumber = random.Next(stopNumber, currentNumber);
    
    // Write the 'currentNumber' to the console
    Console.WriteLine($"Random number: {currentNumber}");
}


