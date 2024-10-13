"use client";

import { Button } from "@/components/ui/button";
import {
    Sheet,
    SheetContent,
    SheetTrigger,
} from "@/components/ui/sheet";
import { Menu, Home, PackageOpen, HelpCircle, Settings, LucideIcon } from 'lucide-react';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import Logo from './logo';
import { cn } from '@/lib/utils';
import { navElements } from '@/lib/nav-elements';

export function Sidebar() {
    const pathname = usePathname();

    const NavItems = () => (
        <div className="space-y-4 py-4">
            <div className="px-3 py-2">
                <h2 className="mb-2 px-4 text-lg font-semibold tracking-tight">
                    <Logo />
                </h2>
                <div className="space-y-2">
                    {navElements.map((item, index) => (
                        <Link
                            key={index}
                            href={item.href}
                            className={cn(
                                "flex items-center w-full p-2 rounded-md hover:bg-slate-100",
                                pathname.includes(item.href.slice(1)) && "bg-slate-100"
                            )}
                        >
                            <item.icon className="mr-2 h-4 w-4" />
                            {item.title}
                        </Link>
                    ))}
                </div>
            </div>
        </div>
    );

    return (
        <div className="hidden h-full md:flex md:w-72 md:flex-col border-r bg-white min-h-screen">
            <div className="flex flex-col flex-grow pt-5 overflow-y-auto">
                <NavItems />
            </div>
        </div>
    );
}

export function MobileSidebar() {
    return (
        <Sheet>
            <SheetTrigger asChild>
                <Button variant="outline" size="icon" className="md:hidden">
                    <Menu className="h-6 w-6" />
                    <span className="sr-only">Toggle navigation menu</span>
                </Button>
            </SheetTrigger>
            <SheetContent side="left" className="p-0">
                <Sidebar />
            </SheetContent>
        </Sheet>
    );
}