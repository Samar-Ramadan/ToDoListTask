import React, { useState } from "react";
import axios from "axios";
import api from "./Api";

export default function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    const handleLogin = async (e) => {
        e.preventDefault(); // يمنع إعادة تحميل الصفحة
        setError("");

        try {
            const res = await api.post("/Login/Login", { username, password });

            // خزن التوكن بالـ localStorage
            localStorage.setItem("token", res.data.token);

            alert("✅ تسجيل الدخول ناجح!");
            // مثال: تحويل المستخدم لصفحة أخرى
            // window.location.href = "/home";
        } catch (err) {
            setError("خطأ في البريد أو كلمة المرور");
        }
    };

    return (
        <div className="d-flex justify-content-center align-items-center vh-100 bg-light">
            <div className="card shadow p-4" style={{ width: "22rem" }}>
                <h2 className="text-center mb-4">🔐 تسجيل الدخول</h2>

                {error && <p className="text-danger text-center">{error}</p>}

                {/* ربط الفورم مع handleLogin */}
                <form onSubmit={handleLogin}>
                    <div className="mb-3">
                        <input
                            type="text"
                            placeholder="الاسم"
                            className="form-control"
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <input
                            type="password"
                            placeholder="كلمة المرور"
                            className="form-control"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-100">
                        دخول
                    </button>
                </form>
            </div>
        </div>
    );
}
