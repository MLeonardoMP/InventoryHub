<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css">

# 🔧 Full-Stack Integration Capstone Project

A modern full-stack application demonstrating the integration of Blazor WebAssembly frontend with ASP.NET Core minimal API backend, developed as part of the Microsoft Fullstack Developer course on Coursera.

## ✨ Features

### 🖥️ Frontend (Blazor WebAssembly)

- **Product Catalog Display**: Interactive product listing with category information
- **Responsive UI**: Built with Bootstrap for a responsive design that works on any device
- **Component-Based Architecture**: Modular, reusable Blazor components
- **Efficient Data Binding**: Seamless integration with backend API data
- **Loading State Handling**: Improved user experience during data fetching operations

### ⚙️ Backend (ASP.NET Core Minimal API)

- **RESTful API Endpoints**: Clean, modern API design using minimal API syntax
- **Multi-Layer Caching Strategy**:
  - In-memory cache with custom expiration policies
  - HTTP response caching with appropriate cache headers
  - Output caching for optimized response delivery
- **CORS Configuration**: Secure cross-origin resource sharing setup
- **OpenAPI Integration**: API documentation and testing support

### 🚀 Performance Optimizations

- **Memory Caching**: Reduces database hits for frequently accessed product data
- **Sliding Expiration**: Cache entries remain valid while in active use
- **Cache Prioritization**: High-priority caching for critical data
- **HTTP Caching Headers**: Browser-level caching for improved performance
- **Conditional Rendering**: Efficient UI updates only when needed

## 🏁 Getting Started

1. Clone the repository
2. Navigate to the Server directory and run: `dotnet run`
3. Navigate to the client directory and run: `dotnet run`
4. Open your browser to `http://localhost:5274` to see the application

## 📂 Project Structure

- 📱 `/client` - Blazor WebAssembly frontend application
- 🖧 `/Server` - ASP.NET Core minimal API backend
- 📝 `/REFLECTION.md` - Development process and Microsoft Copilot insights

## 💡 Development Insights

This project was developed with assistance from Microsoft Copilot. For a detailed reflection on how AI pair programming enhanced the development process, including specific examples of time-saving suggestions and performance optimizations, see the [REFLECTION.md](REFLECTION.md) document.

> The REFLECTION.md file provides valuable insights into using AI-assisted development tools for full-stack applications, including concrete examples of how Microsoft Copilot improved development efficiency by approximately 40% through intelligent code generation and troubleshooting assistance.

## 🛠️ Technologies Used

- 📌 ASP.NET Core 9.0
- 🌐 Blazor WebAssembly
- 🧰 C#
- 🎨 HTML/CSS
- 📊 Bootstrap
- 💾 Memory Caching
- 📦 Git
- 🤖 Microsoft Copilot

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.
