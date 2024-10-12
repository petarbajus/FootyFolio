export default function layout({ children }: Readonly<{ children: React.ReactNode; }>) {
    return (
        <div className="flex h-screen w-screen flex-col items-center justify-center">
            {children}
        </div>
    )
}