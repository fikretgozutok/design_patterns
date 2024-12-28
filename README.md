# Index

- [Singleton](#singleton)
- [Factory Method](#factoryMethod)
- [Abstract Factory](#abstractFactory)
- [Prototype](#prototype)
- [Builder](#builder)

# Singleton Design Pattern - Logger Example {#singleton}

## What is Singleton?
Singleton is a design pattern that ensures a class has only one instance and provides a global point of access to it.

## Example
In this example, we implement a `Logger` class as a singleton. This class is used to log messages across the application while ensuring that only one instance of the logger exists.

## Key Features:
1. **Thread-Safe Implementation**: Ensures the instance is created safely in multithreaded environments.
2. **Global Access**: Provides a global point of access to the logger.

## Usage:
- Run the application, and observe that all messages are logged by the same instance of `Logger`.
- Verify singleton behavior by checking `Object.ReferenceEquals(logger1, logger2)`.

# Factory Method Design Pattern - Message Sender Example {#factoryMethod}

## What is Factory Method?
The Factory Method is a design pattern that provides an interface for creating objects in a super class but allows subclasses to alter the type of objects that will be created.

## Example
In this example, we implement a messaging system that supports sending messages via SMS, Email, and Push Notifications. A factory method is used to determine which message sender to create based on a given input.

## Key Features:
1. **Dynamic Object Creation**: Enables the creation of specific objects (e.g., `SmsSender`, `EmailSender`) based on the input.
2. **Scalability**: New message types can be added easily without modifying the existing factory logic.

## Usage:
- Use the `MessageSenderFactory.CreateSender` method to dynamically create the required sender.
- Call the `SendMessage` method of the sender to send a message.

# Abstract Factory Design Pattern - UI Components Example {#abstractFactory}

## What is Abstract Factory?
Abstract Factory is a design pattern that provides an interface for creating families of related or dependent objects without specifying their concrete classes.

## Example
In this example, we implement a UI rendering system that supports different operating systems (Windows and Mac). Each OS has its own family of UI components (Button, Checkbox). The Abstract Factory pattern ensures the correct set of UI components is created for the selected OS.

## Key Features:
1. **Family of Objects**: Ensures related objects (e.g., `WindowsButton` and `WindowsCheckbox`) are created together.
2. **Flexibility**: Easily add new families (e.g., Linux) without changing existing code.
3. **Separation of Concerns**: Decouples the client code from the concrete classes of the products.

## Usage:
- Run the application and enter the OS type (`windows` or `mac`) when prompted.
- Observe that the correct set of UI components is rendered for the chosen OS.

# Factory Method vs Abstract Factory

| Feature                | Factory Method                                      | Abstract Factory                                  |
|------------------------|----------------------------------------------------|-------------------------------------------------|
| **Purpose**            | Determines which type of object a class will create. | Creates a group of related or dependent objects. |
| **Number of Objects**  | Produces a single type of object.                  | Produces multiple types of related objects.     |
| **Level of Abstraction** | Provides lower-level abstraction.                 | Provides higher-level abstraction.              |
| **Implementation**     | Uses a single factory method.                      | Uses an interface to create multiple products.  |
| **Flexibility**        | Works with a single family of products.            | Works with a group of related objects.          |
| **Example Usage**      | Messaging (e.g., SMS, Email).                      | Themes or UI components (e.g., Button, Checkbox). |

# Prototype Design Pattern - GUI Example {#prototype}

## What is Prototype
The Prototype Design Pattern is used to create a new object by copying an existing object. This pattern is useful when object creation is expensive or complex.

## Key Features
- Creates a clone of an existing object using the `ShallowCopy()` or `DeepCopy()` method.
- Useful for scenarios where object creation cost is high.

## Example
In this project, we implemented the Prototype pattern using a GUI example. We created two shapes:
- **Circle**: Has properties like `Radius` and `Color`.
- **Square**: Has properties like `SideLength` and `Color`.

## Shallow Copy vs Deep Copy

| Feature              | Shallow Copy                                      | Deep Copy                                       |
|----------------------|---------------------------------------------------|------------------------------------------------|
| **Object References**| Copies references to objects.                    | Copies objects and their references.           |
| **Memory Usage**     | Lower memory usage since references are shared.  | Higher memory usage due to full duplication.   |
| **Independence**     | Changes in referenced objects affect the copy.   | Changes in referenced objects do not affect the copy. |
| **Performance**      | Faster to create.                                | Slower to create due to recursion/duplication. |

# Builder Design Pattern - Pizza Ordering System Example {#builder}

### **Overview**
The **Builder Design Pattern** is a creational pattern that provides a way to construct a complex object step by step. It allows for creating different types of objects with the same construction process. This pattern is especially useful when the object creation process involves many steps, with some optional parts or variations.

### **Components of the Builder Pattern**

1. **Builder**: Defines the methods for creating the parts of the complex object.
2. **ConcreteBuilder**: Implements the Builder interface and assembles the parts of the product.
3. **Director**: Controls the construction process. It uses a Builder instance to construct the product.
4. **Product**: The complex object that is being created.

### **When to Use the Builder Pattern**
- When the object creation process involves multiple steps and variations.
- When an object needs to be constructed in a step-by-step manner.
- When an object’s construction process should be independent of the parts that make it up.

### **Example**
In this example, we will demonstrate how to use the Builder pattern to create different types of pizzas. We will have two types of pizzas: **Margherita Pizza** and **Pepperoni Pizza**. The process of creating a pizza involves setting the dough, sauce, and toppings.
