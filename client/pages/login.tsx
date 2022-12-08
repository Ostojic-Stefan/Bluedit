import Head from "next/head";
import Link from "next/link";
import axios from 'axios';
import { FormEvent, useState } from "react";

export default function Register() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const submitForm = async function(event: FormEvent) {
        event.preventDefault();
        const res = await axios.post("https://localhost:7227/api/Auth/login", {
            email,
            password
        });
        console.log(res.headers);
    }

    return (
        <div className='flex gap-4 items-center'>
            <Head>
                <title>Login</title>
            </Head>
            <div className="w-40 h-screen bg-cover bg-center"
                style={{backgroundImage: "url('images/auth-img.jpg')"}}
            ></div>
            <div className='flex flex-col gap-10 w-80'>
                <h1 className="text-4xl">Log in</h1>
                <form onSubmit={submitForm}>
                    <div className="mb-2">
                        <input
                            type="email"
                            className="w-full px-3 py-2 bg-gray-100 border border-gray-400 rounded"
                            placeholder="Email"
                            onChange={(e) => setEmail(e.target.value)}
                        />
                    </div>
                    <div className="mb-2">
                        <input
                            type="password"
                            className="w-full px-3 py-2 bg-gray-100 border border-gray-400 rounded"
                            placeholder="Password"
                            onChange={(e) => setPassword(e.target.value)}
                        />
                    </div>

                    <button className="bg-blue-500 py-2 w-full text-white font-bold text-lg">Continue</button>
                </form>
                <span>Don't have an account?
                <Link className="ml-1 text-blue-500 uppercase" href="/register">
                   Register
                </Link> instead</span>
            </div>
        </div>
    );
}