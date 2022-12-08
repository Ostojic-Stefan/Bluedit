import Head from "next/head";
import Link from "next/link";
import axios from 'axios';
import { FormEvent, useState } from "react";

export default function Register() {

    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const submitForm = async function(event: FormEvent) {
        event.preventDefault();
        const res = await axios.post("https://localhost:7227/api/Auth/register", {
            email,
            username,
            password
        });
        console.log(res);
    }

    return (
        <div className='flex gap-4 items-center'>
            <Head>
                <title>Register</title>
            </Head>
            <div className="w-40 h-screen bg-cover bg-center"
                style={{backgroundImage: "url('images/auth-img.jpg')"}}
            ></div>
            <div className='flex flex-col gap-10 w-80'>
                <h1 className="text-4xl">Register</h1>
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
                            type="text"
                            className="w-full px-3 py-2 bg-gray-100 border border-gray-400 rounded"
                            placeholder="Username"
                            onChange={(e) => setUsername(e.target.value)}
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
                <span>Already a BlueDit user?
                <Link className="ml-1 text-blue-500 uppercase" href="/login">
                   Login
                </Link> instead</span>
            </div>
        </div>
    );
}