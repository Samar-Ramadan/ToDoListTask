import React, { useEffect, useState } from "react";
import axios from "axios";

export default function ToDoApp() {
    const [todos, setTodos] = useState([]);
    const [newTask, setNewTask] = useState("");

    // تحميل المهام من API
    useEffect(() => {
        axios.get("https://localhost:5001/api/todos")
            .then(res => setTodos(res.data))
            .catch(err => console.error(err));
    }, []);

    // إضافة مهمة
    const addTodo = () => {
        if (!newTask.trim()) return;
        axios.post("https://localhost:5001/api/todos", { title: newTask })
            .then(res => setTodos([...todos, res.data]));
        setNewTask("");
    };

    // حذف مهمة
    const deleteTodo = (id) => {
        axios.delete(`https://localhost:5001/api/todos/${id}`)
            .then(() => setTodos(todos.filter(t => t.id !== id)));
    };

    // تبديل حالة المهمة
    const toggleComplete = (id) => {
        const todo = todos.find(t => t.id === id);
        axios.put(`https://localhost:5001/api/todos/${id}`, { ...todo, isDone: !todo.isDone })
            .then(res => {
                setTodos(todos.map(t => (t.id === id ? res.data : t)));
            });
    };

    return (
        <div className="max-w-lg mx-auto mt-10 p-6 bg-white rounded-2xl shadow-lg">
            <h1 className="text-2xl font-bold mb-4 text-center">📋 ToDo List</h1>

            <div className="flex mb-4">
                <input
                    type="text"
                    placeholder="أضف مهمة جديدة..."
                    value={newTask}
                    onChange={(e) => setNewTask(e.target.value)}
                    className="flex-grow border p-2 rounded-l-lg"
                />
                <button onClick={addTodo} className="bg-blue-500 text-white px-4 rounded-r-lg">
                    إضافة
                </button>
            </div>

            <ul>
                {todos.map(todo => (
                    <li key={todo.id} className="flex justify-between items-center mb-2 p-2 border rounded-lg">
                        <span
                            onClick={() => toggleComplete(todo.id)}
                            className={`cursor-pointer ${todo.isDone ? "line-through text-gray-500" : ""}`}
                        >
                            {todo.title}
                        </span>
                        <button
                            onClick={() => deleteTodo(todo.id)}
                            className="bg-red-500 text-white px-2 rounded-lg"
                        >
                            حذف
                        </button>
                    </li>
                ))}
            </ul>
        </div>
    );
}
