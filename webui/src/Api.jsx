import axios from "axios";

// أنشئ instance عام من axios
const api = axios.create({
    baseURL: "https://localhost:7070/api", // الرابط الأساسي
    headers: {
        "Content-Type": "application/json",
        "Accept": "text/plain",
    },
});

// إضافة التوكن أوتوماتيكياً لكل الطلبات إذا موجود
api.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export default api;
