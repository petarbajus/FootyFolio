import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import Link from "next/link";

export default function Home() {
  return (
    <div>
      <Link href="/login">
        <Button>
          Register
        </Button>
      </Link>

      <Link href="/register">
        <Button>
          Login
        </Button>
      </Link>
    </div>
  );
}
